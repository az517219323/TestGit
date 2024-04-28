using UnityEngine;
using System.Collections.Generic;
using ParadoxNotion.Design;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Blackboard/Dictionaries")]
    public class GetDictionaryElement<T> : ActionTask
    {

        [BlackboardOnly]
        [RequiredField]
        [Name("字典")]
        public BBParameter<Dictionary<string, T>> dictionary;
        [Name("键")]
        public BBParameter<string> key;

        [BlackboardOnly]
        [Name("保存至")]
        public BBParameter<T> saveAs;

        protected override string info {
            get { return string.Format("{0} = {1}[{2}]", saveAs, dictionary, key); }
        }

        protected override void OnExecute() {
            if ( dictionary.value == null ) {
                EndAction(false);
                return;
            }
            saveAs.value = dictionary.value[key.value];
            EndAction();
        }
    }
}