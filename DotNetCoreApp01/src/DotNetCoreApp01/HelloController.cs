namespace DotNetCoreApp01 {
    public class HelloController {
        public string Index(string name) {
            return $"hello {name}";
        }
    }
}