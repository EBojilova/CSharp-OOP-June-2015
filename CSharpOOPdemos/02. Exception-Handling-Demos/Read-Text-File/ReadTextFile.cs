using System;
using System.IO;

public class ReadTextFile
{
    private const string FilePath = @"..\..\ReadTextFile.cs";
    
    public static void Main()
    {
        StreamReader reader = null;

        try//jelatelno e da polzvame using, ne try finnaly, no v tozi variant ne mojem da obrabotvame exeptioni, za da gi obrabotvame edinstvenia variant e da minem prez try, catch, finally
        {
            reader = new StreamReader(FilePath);
            int lineNumber = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                Console.WriteLine("Line {0}: {1}", lineNumber, line);
                //throw  new ArithmeticException();//proverka che dori i da gramne ste izpishe Finnaly executed
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("File {0} not found", FilePath);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.Error.WriteLine("File path contains an invalid directory");
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine("Unauthorized access to specified file path");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Unknown IO has occurred. Verify that the file path is correct.");
        }
        finally
        {
            if (reader != null)//ako vse pak sme otvorili niakakav reader(t.e e incializiran s new) i sme procheli nesto go zatvariame
            {
                reader.Close();
            }
            Console.WriteLine("Finnaly executed");
        }
    }
}
