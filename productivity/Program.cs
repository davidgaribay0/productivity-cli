namespace productivity
{

    using System;
    using System.Text;
    using McMaster.Extensions.CommandLineUtils;

    public class Program
    {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        static readonly DateTime currentDate = DateTime.Now;

        [Option(Description = "The name of the file you would like to create", ShortName = "n", LongName = "name")]
        public string Date { get; } = currentDate.ToString("MM-dd-yyyy");

        [Option(Description = "A list of things you would like to do. Seperate each item using a comma (,)", ShortName = "t", LongName = "todos")]
        public string TodosInput { get; } = "";

        private void OnExecute()
        {
            string fileName = $"{Date}.md";
            StringBuilder formattedTodos = new StringBuilder();

            List<string> Todos = TodosInput.Split(",").ToList();

            try
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine("The file already exist. Terminating Application.");
                    return;
                }


                if (Todos.Count != 0)
                {

                    foreach (string todo in Todos)
                    {
                        formattedTodos.Append($"- [ ] {todo.Trim()} \n");
                    }
                }
                else
                {
                    formattedTodos.Append("- [ ] ");
                }


                using StreamWriter sw = File.AppendText(fileName);
                sw.Write(
                $"""
                # {currentDate:dddd, MMMM d, yyyy}

                ## Todo

                {formattedTodos}

                ## Done
                
                - [ ] 

                """
                );
                Console.WriteLine($"Successfully created {fileName}");
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
