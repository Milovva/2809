using _2809.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2809.Controllers
{
    public class MatrixController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Создаем новую модель с инициализацией
            var model = new MatrixModel
            {
                Size = 3, // Начальный размер матриц
                Matrix1 = new int[3, 3], // Инициализируем размер матрицы по умолчанию
                Matrix2 = new int[3, 3],
                Result = new int[3, 3] // Инициализация результирующей матрицы
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Calculate(MatrixModel model)
        {
            // Проверяем размер матриц и инициализируем их
            model.Matrix1 = new int[model.Size, model.Size];
            model.Matrix2 = new int[model.Size, model.Size];

            // Загрузка значений из формы
            for (int i = 0; i < model.Size; i++)
            {
                for (int j = 0; j < model.Size; j++)
                {
                    model.Matrix1[i, j] = Convert.ToInt32(Request.Form[$"Matrix1[{i}][{j}]"]);
                    model.Matrix2[i, j] = Convert.ToInt32(Request.Form[$"Matrix2[{i}][{j}]"]);
                }
            }

            // Сложение матриц
            model.Result = AddMatrices(model.Matrix1, model.Matrix2, model.Size);

            return View("Result", model); // Переход к представлению результата
        }

        private int[,] AddMatrices(int[,] matrix1, int[,] matrix2, int size)
        {
            int[,] result = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }
    }
}
