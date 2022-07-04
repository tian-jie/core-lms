using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLMS.Core.Entities
{
    [Table("orgnize")]
    public class Orgnize : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// orgnize名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// orgnize经理
        /// </summary>
        [Column("manager")]
        public int Manager { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("description")]
        public string Description { get; set; }



    }
}
