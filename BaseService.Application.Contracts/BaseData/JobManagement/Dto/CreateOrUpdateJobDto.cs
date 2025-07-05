namespace BaseService.BaseData.JobManagement.Dto
{
    public class CreateOrUpdateJobDto
    {
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public int Sort { get; set; }

        public string Description { get; set; }
    }
}
