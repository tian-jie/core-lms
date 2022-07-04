using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLMS.Core.Entities
{
    [Table("project_cost")]
    public class ProjectCost : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("project_name")]
        public string ProjectName { get; set; }

        [Column("project_status")]
        public string ProjectStatus { get; set; }

        [Column("year_date")]
        public string YearDate { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("employee_name")]
        public string EmployeeName { get; set; }

        [Column("title_id")]
        public int EmployeeTitleId { get; set; }

        [Column("title_name")]
        public string EmployeeTitleName { get; set; }

        [Column("total_amount")]
        public int TotalAmount { get; set; }



    }
}
