using System.Collections.Generic;

namespace jon {
    public interface IParser<T> {
        List<T> parse(string[] lines);
    }
}