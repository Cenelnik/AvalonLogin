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
    protected string _stSubmit = "";
    protected string _stCancel = "";
    /// <summary>
    /// Подтвердить действие отправив команду
    /// </summary>
    public virtual async Task<bool> Submit()
    {
        return false;
    }

    /// <summary>
    /// Вернутся назад (отменить действие)
    /// </summary>
    public virtual async Task<bool> Return()
    {
        return false;
    }

    public virtual string StSubmit { get => ""; } // _stSubmit; protected set { _stSubmit = value; } 
    public virtual string StCancel { get => "Cancel"; }

    public virtual BasePageViewModel CurrentPage { get; protected set; }
    public virtual async Task ErrorEvent()
    {
        return;
    }
}

