using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMerge.ViewModels
{
    public abstract class UnityBindableBase : BindableBase, INavigationAware
    {
        /// <summary>
        /// DIコンテナを取得します
        /// コンストラクタ実行後に登録するため、コンストラクタ内で設定する場合は別途コンストラクタに引数を受け取って処理してください
        /// </summary>
        [Dependency]
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// DIコンテナからEventAggregatorを登録します
        /// コンストラクタ実行後に登録するため、コンストラクタ内で設定する場合は別途コンストラクタに引数を受け取って処理してください
        /// </summary>
        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

        /// <summary>
        /// 画面から遷移する時に実行
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext) { }

        /// <summary>
        /// 画面から遷移してきた時に実行
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext) { }
    }
}
