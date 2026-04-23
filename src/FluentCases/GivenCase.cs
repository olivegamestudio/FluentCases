namespace FluentCases;

public sealed class GivenCase<TContext>
{
    private readonly TContext _context;

    internal GivenCase(TContext context)
    {
        _context = context;
    }

    public WhenCase<TContext> When(Action<TContext> act)
    {
        if (act == null)
        {
            throw new ArgumentNullException(nameof(act));
        }

        act(_context);

        return new WhenCase<TContext>(_context);
    }
}
