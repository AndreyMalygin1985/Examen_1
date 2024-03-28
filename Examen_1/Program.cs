using System.Collections;
using static System.Console;

class Program
{
    static Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
    static void Main()
    {
        while (true)
        {
            Clear();
            WriteLine("Меню:");
            WriteLine("1. Работа со словарем");
            WriteLine("2. Выход");

            string userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    ShowDictionaryMenu();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("Некорректный выбор. Попробуйте снова.");
                    ReadKey();
                    break;
            }
        }
    }

    static void ShowDictionaryMenu()
    {
        while (true)
        {
            Clear();
            WriteLine("Меню словаря:");
            WriteLine("1. Добавить слово");
            WriteLine("2. Заменить слово");
            WriteLine("3. Удалить слово");
            WriteLine("4. Поиск перевода");
            WriteLine("5. Экспорт переводов");
            WriteLine("6. Назад");

            string userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    AddWord();
                    break;
                case "2":
                    ReplaceWord();
                    break;
                case "3":
                    DeleteWord();
                    break;
                case "4":
                    SearchTranslation();
                    break;
                case "5":
                    ExportTranslations();
                    break;
                case "6":
                    return;
                default:
                    WriteLine("Некорректный выбор. Попробуйте снова.");
                    ReadKey();
                    break;
            }
        }
    }

    static void AddWord()
    {
        WriteLine("Введите слово: ");
        string word = ReadLine();

        WriteLine("Введите переводы через запятую:");
        string translationsInput = ReadLine();
        List<string> translations = new List<string>(translationsInput.Split(','));

        dictionary[word] = translations;

        WriteLine("Слово добавлено в словарь.");
        ReadKey();
    }

    static void ReplaceWord()
    {
        WriteLine("Введите слово для замены: ");
        string word = ReadLine();

        WriteLine("Введите новые переводы через запятую:");
        string translationsInput = ReadLine();
        List<string> translations = new List<string>(translationsInput.Split(','));

        dictionary[word] = translations;

        WriteLine("Слово успешно заменено.");
        ReadKey();
    }

    static void DeleteWord()
    {
        WriteLine("Введите слово для удаления: ");
        string word = ReadLine();

        if (dictionary.ContainsKey(word))
        {
            dictionary.Remove(word);
            WriteLine("Слово успешно удалено из словаря.");
        }
        else
        {
            WriteLine("Слово не найдено в словаре.");
        }
        ReadKey();
    }

    static void SearchTranslation()
    {
        WriteLine("Введите слово для поиска перевода: ");
        string word = ReadLine();

        if (dictionary.ContainsKey(word))
        {
            List<string> translations = dictionary[word];
            WriteLine($"Переводы слова '{word}': {string.Join(", ", translations)}");
        }
        else
        {
            WriteLine("Перевод не найден.");
        }

        ReadKey();
    }

    static void ExportTranslations(string filePath = "E:\\BW321\\source\\repos\\Examen_1\\Examen_1\\bin\\Debug\\net8.0\\Export.txt")
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var entry in dictionary)
            {
                writer.WriteLine(entry.Key + ": " + string.Join(", ", entry.Value));
            }
        }
        WriteLine("Словарь успешно экспортирован в файл.");
    }
}