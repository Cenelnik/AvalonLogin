using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AvalonLogin.ViewModels;

/// <summary>
/// Модель базового функционала любой страницы
/// </summary>
public abstract class BasePageViewModel : ViewModelBase
{
    /// <summary>
    /// Подтвердить действие отправив команду
    /// </summary>
    public virtual bool Submit { get; set; }

    /// <summary>
    /// Вернутся назад (отменить действие)
    /// </summary>
    public virtual bool Return { get; set; }

    public virtual string StSubmit { get => ""; }
    public virtual string StCancel { get => "Cancel"; } 
}

