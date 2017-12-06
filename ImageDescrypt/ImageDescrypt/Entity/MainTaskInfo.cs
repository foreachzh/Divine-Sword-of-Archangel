using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    class MainTaskInfo:Bean
    {
        private int _modelId;

        private int _isFinshAction;

        private List<TaskAttribute> _permiseGoods;

        private List<TaskAttribute> _permiseMonster;

        private List<int> _permiseAchieve;

        private List<TaskAttribute> _permiseStrong;

        private List<TaskAttribute> _permiseWear;

        private List<TaskAttribute> _permiseElse;
        public override void reading()
        {
            this._modelId = readInt();
            this._isFinshAction = readByte();
            _permiseGoods = readObjList<TaskAttribute, TaskAttribute>();
            _permiseMonster = readObjList<TaskAttribute, TaskAttribute>();
            _permiseAchieve = readObjList<int, int>();
            _permiseStrong = readObjList<TaskAttribute, TaskAttribute>();
            _permiseElse = readObjList<TaskAttribute, TaskAttribute>();
            _permiseWear = readObjList<TaskAttribute, TaskAttribute>();
            //base.reading();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_modelId={0};_isFinshAction={1};_permiseGoods.cnt={2};_permiseMonster.cnt={3};_permiseAchieve.cnt={4};_permiseStrong.cnt={5};_permiseWear.cnt={6};_permiseElse.cnt={7};"
            , _modelId, _isFinshAction, _permiseGoods.Count, _permiseMonster.Count, _permiseAchieve.Count, _permiseStrong.Count, _permiseWear.Count, _permiseElse.Count);

            return outstr;
        }

    }

    public class TaskAttribute : Bean
    {
        private int _model;

        private int _num;

        public override void reading()
        {
            this._model = readInt();
            this._num = readInt();
            // base.reading();
        }
    }
}
