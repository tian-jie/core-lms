using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kevin.T.Clockify.Data.Entities
{
    [Table("timeentry")]
    public class TimeEntry : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Clockify里的id字符串
        /// </summary>
        [Column("gid")]
        public virtual string Gid { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 用户id，用clockify里的userid字符串
        /// </summary>
        [Column("userid")]
        public virtual string UserId { get; set; }

        /// <summary>
        /// 项目ID，clockify里的项目id字符串
        /// </summary>
        [Column("projectid")]
        public virtual string ProjectId { get; set; }

        /// <summary>
        /// TaskId，clockify里的项目id字符串
        /// </summary>
        [Column("taskid")]
        public virtual string TaskId { get; set; }

        /// <summary>
        /// 录入时间的那一天，格式：20200101
        /// </summary>
        [Column("date")]
        public virtual int Date { get; set; }

        /// <summary>
        /// 记录这个的时间，精确到秒
        /// </summary>
        [Column("totalamount")]
        public virtual long TotalAmount { get; set; }

        /// <summary>
        /// clockify里的workspace概念
        /// </summary>
        [Column("workspaceid")]
        public virtual string WorkspaceId { get; set; }

        /// <summary>
        /// 是否锁定，锁定后不可修改
        /// </summary>
        [Column("islocked")]
        public virtual bool IsLocked { get; set; }

        /// <summary>
        /// 冗余的Task里的isBilliable信息
        /// </summary>
        [Column("isbillable")]
        public virtual bool IsBillable { get; set; }

        ///// <summary>
        ///// 创建日期，框架直接调用
        ///// </summary>
        //[Column("createddate")]
        //public long CreatedDate { get; set; }

        /// <summary>
        /// 创建人ID，框架直接调用
        /// </summary>
        [Column("createduserid")]
        public string CreatedUserID { get; set; }

        ///// <summary>
        ///// 更新日期，框架直接调用
        ///// </summary>
        //[Column("updated")]
        //public long UpdatedDate { get; set; }

        /// <summary>
        /// 更新人ID，框架直接调用
        /// </summary>
        [Column("updateduserid")]
        public string UpdatedUserID { get; set; }

        /// <summary>
        /// 逻辑删除，框架直接调用
        /// </summary>
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
    }

}
