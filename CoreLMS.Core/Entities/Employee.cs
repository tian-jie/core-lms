using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kevin.T.Clockify.Data.Entities
{
    [Table("employee")]
    public class Employee : IEntity
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
        /// 邮箱
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }


        [Column("function")]
        public string Function { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("team")]
        public int Team { get; set; }

        [Column("title")]
        public int Title { get; set; }

        [Column("employeement")]
        public int Employeement { get; set; }

        [Column("date_join")]
        public DateTime DateJoin { get; set; }

        [Column("date_left")]
        public DateTime DateLeft { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("memo")]
        public string Memo { get; set; }

    }
}
