using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kevin.T.Clockify.Data.Entities
{
    [Table("project_task")]
    public class ProjectTask : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Clockify里的id字符串
        /// </summary>
        public virtual string Gid { get; set; }

        /// <summary>
        /// Clockify里的id字符串
        /// </summary>
        public virtual string ProjectGid { get; set; }

        /// <summary>
        /// Task名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Task状态
        /// </summary>
        public string Status { get; set; }




        /// <summary>
        /// 创建日期，框架直接调用
        /// </summary>
        [Column("created")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 创建人ID，框架直接调用
        /// </summary>
        [Column("created_user")]
        public string CreatedUserID { get; set; }

        /// <summary>
        /// 更新日期，框架直接调用
        /// </summary>
        [Column("updated")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 更新人ID，框架直接调用
        /// </summary>
        [Column("updated_user")]
        public string UpdatedUserID { get; set; }

        /// <summary>
        /// 逻辑删除，框架直接调用
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

    }
}
