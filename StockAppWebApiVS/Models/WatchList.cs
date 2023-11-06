using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApiVS.Models
{
    [Table("watchlists")]
    public class WatchList
    {
        [Key]
        [ForeignKey("User")]
        [Column("user_id")]
        public int? UserId { get; set; }

        [Key]
        [ForeignKey("Stock")]
        [Column("stock_id")]
        public int? StockId { get; set; }

        public User? User { get; set; }

        public Stock? Stock { get; set; }
    }
}
