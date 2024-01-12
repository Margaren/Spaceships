namespace TxtFIleRead
{
    public static class ReaderClass
    {
        public static string[] Read(string file)
        {
            var fileName = file;
            var dataAsArray = File.ReadAllLines(fileName);
            return dataAsArray;
        }
        public static void Write(string[] str)
        {
            var fileNameArray = @"E:\aip\Spaceships\Lab_6\Lab_6_Out.txt";
            var dataArray = str;
            File.WriteAllLines(fileNameArray, dataArray);
        }
    }
}