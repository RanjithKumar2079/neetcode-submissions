public class Solution {

    public string Encode(IList<string> strs) {
        List<char> final = new List<char>();
        const int secret = 256;
        final.Add((char)strs.Count);
        foreach(var str in strs){
            final.Add((char)str.Length);
            foreach(var c in str){
                int val = c + secret;
                final.Add((char)val);
            }
        }
        return new string(final.ToArray());
    }

    public List<string> Decode(string s) {
        int wordsCount = (int)s[0];
        const int secret = 256;
        List<string> result = new List<string>();
        int i = 1;
        while(result.Count != wordsCount && i < s.Length){
            int wordCount = (int)s[i];
            char[] word = new char[wordCount];
            int index = 0;
            for(int j = i+1; j <= wordCount + i; j++){
                word[index]=(char)(s[j] - secret);
                index++;
            }
            result.Add(new string(word.ToArray()));
            i = i + wordCount + 1;
        }
        return result;
    }
}
