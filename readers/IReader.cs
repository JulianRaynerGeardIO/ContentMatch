using System.Collections.Generic;

namespace jon {
    public interface IReader<T> {
        List<T> read(string filename, IParser<T> parser);
    }
}