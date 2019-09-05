using System.Collections.Generic;
using System.IO;

namespace jon {
    public class FileReader<T> : IReader<T> {
        public List<T> read(string filename, IParser<T> parser) {
            try {
                string[] lines = File.ReadAllLines(filename);
                return parser.parse(lines);
            }
            catch(FileNotFoundException) {
                return new List<T>();
            }
        }
    }
}