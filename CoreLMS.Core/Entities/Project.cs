using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLMS.Core.Entities
{
    [Table("project")]
    public class Project : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Clockify里的id字符串
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 项目经理
        /// </summary>
        [Column("project_manager")]
        public int ProjectManager { get; set; }
        
        /// <summary>
        /// 项目开始时间
        /// </summary>
        [Column("start_time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 项目结束时间
        /// </summary>
        [Column("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 客户，非关联外键
        /// </summary>
        public int Client { get; set; }

        /// <summary>
        /// 公司内部组织架构的组，非关联外键
        /// </summary>
        public int Team { get; set; }

        /// <summary>
        /// 项目持续时长，天
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 项目状态，包括： Not Started / Projection / Ongoing / On Hold / Completed / Canceled 
        /// </summary>
        [Column("project_status")]
        public string ProjectStatus { get; set; }

        /// <summary>
        /// 项目的商务状态，包括 签订前 (High/Medium/Low), 签订后 (Signed/Confirmed)，内部项目的(Misc.)
        /// </summary>
        [Column("business_status")]
        public string BusinessStatus { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }



    }
}
