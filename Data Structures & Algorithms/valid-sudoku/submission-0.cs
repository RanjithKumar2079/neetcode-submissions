public class Solution {
    public static bool CheckSubbox(char[][] board,int i,int j){
        var dict = new Dictionary<char, int>();
        for(int z=i; z<i+3; z++){
            for(int x=j; x<j+3; x++){
                if (board[z][x] == '.'){
                    continue;
                }
                if(dict.ContainsKey(board[z][x])){
                    return false;
                }
                dict[board[z][x]]=1;
            }
        }
        return true;
    }

    public static bool CheckRow(char[][] board,int i){
        var dict = new Dictionary<char, int>();
        var cols = board[i].Length;
        var row = board[i];
        for(int z=0; z<cols; z++){
            if (row[z] == '.'){
                continue;
            }
            if(dict.ContainsKey(row[z])){
                return false;
            }
            
            dict[row[z]] = 1;
        }
        return true;
    }

    public static bool CheckCol(char[][] board,int j){
        var dict = new Dictionary<char, int>();
        var rows = board.Length;
        for(int z=0; z<rows; z++){
            if (board[z][j] == '.'){
                continue;
            }
            if(dict.ContainsKey(board[z][j])){
                return false;
            }
            
            dict[board[z][j]] = 1;
        }
        return true;
    }

    public bool IsValidSudoku(char[][] board) {
        bool valid = true;
        for(int i=0; i<board.Length; i++){
            valid = CheckRow(board, i);
            if (!valid){
                return valid;
            }
        }

        for(int j=0; j<board[0].Length; j++){
            valid = CheckCol(board, j);
            if (!valid){
                return valid;
            }
        }

        for(int i=0; i<board.Length; i=i+3){
            for(int j=0; j<board[i].Length; j=j+3){
                valid = CheckSubbox(board, i, j);
                if (!valid){
                    return valid;
                }
            }
        }

        return valid;
    }
}
