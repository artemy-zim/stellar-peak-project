using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public async Task LoadSceneAsync(string sceneName, System.Action<float> onProgress)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.isDone == false)
        {
            onProgress?.Invoke(asyncOperation.progress / 0.9f);

            if (asyncOperation.progress >= 0.9f)
                asyncOperation.allowSceneActivation = true;

            await Task.Yield();
        }
    }
}
