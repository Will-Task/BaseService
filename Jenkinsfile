def GetVersion() {
  return new Date().format("yyyyMMdd.HHmmss", TimeZone.getTimeZone('Asia/Taipei'))
}
def imageTag = GetVersion()

pipeline {
  agent {
    kubernetes {
      yaml """
apiVersion: v1
kind: Pod
metadata:
  namespace: devops-tools
  labels:
    some-label: docker
spec:
  serviceAccountName: jenkins-admin
  volumes:
    - name: docker-graph-storage
      emptyDir: {}
    - name: workspace-volume
      emptyDir: {}
  containers:
    - name: docker
      image: docker:24.0-dind
      securityContext:
        privileged: true
      resources:
        requests:
          memory: "1Gi"
          cpu: "1"
        limits:
          memory: "2Gi"
          cpu: "2"
      volumeMounts:
        - mountPath: /var/lib/docker
          name: docker-graph-storage
        - mountPath: /home/jenkins/agent
          name: workspace-volume
      env:
        - name: DOCKER_TLS_CERTDIR
          value: ""
      command:
        - dockerd-entrypoint.sh
      args:
        - --host=tcp://0.0.0.0:2375
        - --host=unix:///var/run/docker.sock
      tty: true
    - name: docker-client
      image: docker:24.0-cli
      command:
        - cat
      env:
        - name: DOCKER_HOST
          value: tcp://localhost:2375
      tty: true
    - name: kubectl
      image: lachlanevenson/k8s-kubectl
      command:
        - cat
      tty: true
  restartPolicy: Never
"""
    }
  }

  environment {
    dockerUser = 'will1233'
    dockerPwd = 'Az@98198506'
  }

  stages {
    stage('pull code') {
      steps {

        checkout([
          $class: 'GitSCM',
          branches: [[name: "${env.BRANCH_NAME}"]],
          userRemoteConfigs: [[
            url: 'https://github.com/Will-Task/BaseService.git',
            credentialsId: '3222b5bc-6057-4ccd-a353-aa07b2b9ff36'
          ]]
        ])
        echo '---pull code from git-hub success---'
      }
    }

    stage('通過Docker構建image') {
      steps {
        container('docker-client') {
          sh "docker build -f ${WORKSPACE}/BaseService.Host/Dockerfile -t ${dockerUser}/${env.JOB_NAME}:latest ${WORKSPACE}"
          echo '通過Docker構建image - SUCCESS'
        }
      }
    }

    stage('將image推送到 Docker hub') {
      steps {
        container('docker-client') {
          sh """
            docker login -u ${dockerUser} -p ${dockerPwd}
            docker push ${dockerUser}/${env.JOB_NAME}:latest
          """
        }
        echo '將image推送到 Docker hub - SUCCESS'
      }
    }
	
	stage('Deploy') {
	  steps {
		container('kubectl') {
		  script {
			checkout([
			  $class: 'GitSCM',
			  branches: [[name: "${env.BRANCH_NAME}"]],
			  userRemoteConfigs: [[
				url: 'https://github.com/Will-Task/BaseService.git',
				credentialsId: '3222b5bc-6057-4ccd-a353-aa07b2b9ff36'
			  ]]
			])

			sh 'kubectl apply -f ${WORKSPACE}/deploy.yaml'
			echo '---deploy success---'
		  }
		}
	  }
	}
  }
}
