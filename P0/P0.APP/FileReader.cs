public static class FileReader{

    public static string ReadFile(string pathname){
        
        using(StreamReader reader = new StreamReader(pathname)){
            return reader.ReadToEnd();
        }
    }
}