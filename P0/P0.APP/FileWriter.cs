public static class FileWriter{
    
    public static void WriteFile(string pathname, string content){

        using(StreamWriter writer = new StreamWriter(pathname)){
            writer.WriteLine(content);
        }
    }
}