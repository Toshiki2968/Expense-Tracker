namespace ExpenseTracker.Models
{
    public class Expense
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id {get; set;}
        
        /// <summary>
        /// 説明
        /// </summary>
        public string Description {get; set;} = string.Empty;
        
        /// <summary>
        /// 経費
        /// </summary>
        public decimal Amount {get; set;}
        
        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime CreatedAt {get; set;}
        
        /// <summary>
        /// カテゴリ
        /// </summary>
        public string Category {get; set;} = string.Empty;
    }
}