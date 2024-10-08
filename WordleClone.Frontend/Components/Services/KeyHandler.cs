namespace WordleClone.Frontend.Components.Services;

public class KeyHandler
{
    public event Action<char> OnLetterAdded;
    public event Action OnCheckWord;
    public event Action OnDeleteLetter;

    public void HandleKey(string key)
    {
        switch (key)
        {
            case "Enter":
                OnCheckWord?.Invoke();
                break;
            case "Backspace":
                OnDeleteLetter?.Invoke();
                break;
            default:
                if (key.Length == 1 && char.IsLetter(key[0]))
                {
                    OnLetterAdded?.Invoke(key[0]);
                }
                break;
        }
    }
}
