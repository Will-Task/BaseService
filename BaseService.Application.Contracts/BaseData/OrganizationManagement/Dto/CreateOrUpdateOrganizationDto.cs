using System;
using System.ComponentModel.DataAnnotations;

namespace BaseService.BaseData.OrganizationManagement.Dto
{
    public class CreateOrUpdateOrganizationDto
    {
        public short CategoryId { get; set; }

        public Guid? Pid { get; set; }

        [Required]
        public string Name { get; set; }

        public int Sort { get; set; }

        public bool Enabled { get; set; }
    }
}
