using UnityEngine;
using System.Collections.Generic;
using ParadoxNotion.Design;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Blackboard/Dictionaries")]
    public class AddElementToDictionary<T> : ActionTask
    {

        [BlackboardOnly]
        [RequiredField]
        [Name("字典")]
        public BBParameter<Dictionary<string, T>> dictionary;

        [Name("键")]
        public BBParameter<string> key;
        [Name("值")]
        public BBParameter<T> value;

        protected override string info {
            get { return string.Format("{0}[{1}] = {2}", dictionary, key, value); }
        }

        protected override void OnExecute() {
            if ( dictionary.value == null ) {
                EndAction(false);
                return;
            }
            dictionary.value[key.value] = value.value;
            EndAction();
        }
    }
}