﻿namespace MessageReader.WebJob.Mappings
{
    public interface IMapper
    {
       Out MapIt<In, Out>(In entry);
    }
}