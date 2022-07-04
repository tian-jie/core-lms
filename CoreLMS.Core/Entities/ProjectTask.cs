using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLMS.Core.Entities
{
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


    }
}
