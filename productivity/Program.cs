namespace productivity
{

    using System;
    using McMaster.Extensions.CommandLineUtils;

    public class Program
    {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        static readonly DateTime currentDate = DateTime.Now;

        [Option(Description = "The name of the file you would like to create", ShortName = "n", LongName = "name")]
        public string Date { get; } = currentDate.ToString("MM-dd-yyyy");

        private void OnExecute()
        {
            string fileName = $"{Date}.md";

            try
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine("The file already exist. Terminating Application.");
                    return;
                }

                using StreamWriter sw = File.AppendText(fileName);
                sw.Write(
                $"""
                # {currentDate:dddd, MMMM d, yyyy}

                ## Todo

                - [ ] 
                - [ ] 

                ## Done
                - [ ] 
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
