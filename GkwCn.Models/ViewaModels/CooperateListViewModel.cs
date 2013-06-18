using GkwCn.Domains;
using GkwCn.Domains.Business;
/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2013/6/9
 * 时间: 21:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace GkwCn.Models.ViewModels
{
	/// <summary>
	/// Description of CooperateListViewModel.
	/// </summary>
	public class CooperateListViewModel:BaseListViewModel<Cooperate>
	{
        public int? Type { get; set; }
	}
}
