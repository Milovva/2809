namespace _2809.Models
{
    public class MatrixModel
    {
        public int Size { get; set; }
        public int[,] Matrix1 { get; set; }
        public int[,] Matrix2 { get; set; }
        public int[,] Result { get; set; }

        public MatrixModel()
        {
            // Инициализируем массивы по умолчанию
            Matrix1 = new int[3, 3];
            Matrix2 = new int[3, 3];
            Result = new int[3, 3];
        }
    }
}
