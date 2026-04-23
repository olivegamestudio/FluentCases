namespace FluentCases;

public static class Case
{
    /// <summary>
    /// Arranges the context
    /// </summary>
    /// <param name="context"></param>
    /// <param name="arrange"></param>
    /// <typeparam name="TContext"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static GivenCase<TContext> Given<TContext>(TContext context, Action<TContext> arrange)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (arrange is null)
        {
            throw new ArgumentNullException(nameof(arrange));
        }

        arrange(context);
        return new GivenCase<TContext>(context);
    }

    /// <summary>
    /// Arranges the context
    /// </summary>
    /// <param name="create"></param>
    /// <param name="arrange"></param>
    /// <typeparam name="TContext"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static GivenCase<TContext> Given<TContext>(Func<TContext> create, Action<TContext> arrange)
    {
        if (create is null)
        {
            throw new ArgumentNullException(nameof(create));
        }

        if (arrange == null)
        {
            throw new ArgumentNullException(nameof(arrange));
        }

        TContext? context = create();

        if (context is null)
        {
            throw new ArgumentNullException(nameof(create), "The context factory returned null.");
        }

        arrange(context);
        return new GivenCase<TContext>(context);
    }
}
