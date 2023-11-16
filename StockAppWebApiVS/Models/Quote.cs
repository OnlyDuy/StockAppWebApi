using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApiVS.Models
{
    [Table("quotes")]
    public class Quote
    {
        [Key]
        [Column("quote_id")]
        public int QuoteId { get; set; }

        [ForeignKey("Stock")]
        [Column("stock_id")]
        public int StockId { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("change")]
        public decimal Change { get; set; }

        [Column("percent_change")]
        public decimal PercentChange { get; set; }

        [Column("volume")]
        public int Volume { get; set; }

        [Column("time_stamp")]
        public DateTime TimeStamp { get; set; }

        //navigation field
        public Stock? Stock { get; set; }
    }
}
