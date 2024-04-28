using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions
{

    [Category("Application")]
    public class LoadScene : ActionTask
    {

        [RequiredField]
        [Name("场景名称")]
        public BBParameter<string> sceneName;
        [Name("加载模式")]
        public BBParameter<LoadSceneMode> mode;

        protected override string info {
            get { return string.Format("Load Scene {0}", sceneName); }
        }

        protected override void OnExecute() {
            SceneManager.LoadScene(sceneName.value, mode.value);
            EndAction();
        }
    }
}