namespace RedBerylBookStore.DataModels.Base
{
    using System;

    public interface IBaseModel
    {
        int LastModifiedBy { get; set; }

        DateTime LastModifiedOn { get; set; }
    }
}