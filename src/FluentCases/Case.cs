namespace FluentCases;

public static class Case
{
    public static GivenCase<TContext> Given<TContext>(TContext context, Action<TContext> arrange)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (arrange == null)
        {
            throw new ArgumentNullException(nameof(arrange));
        }

        arrange(context);

        return new GivenCase<TContext>(context);
    }

    public static GivenCase<TContext> Given<TContext>(Func<TContext> create, Action<TContext> arrange)
    {
        if (create == null)
        {
            throw new ArgumentNullException(nameof(create));
        }

        if (arrange == null)
        {
            throw new ArgumentNullException(nameof(arrange));
        }

        var context = create();

        if (context == null)
        {
            throw new ArgumentNullException(nameof(create), "The context factory returned null.");
        }

        arrange(context);

        return new GivenCase<TContext>(context);
    }
}
