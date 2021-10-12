using System.Security.Claims;
using System.Threading;

namespace Api
{
    public class ClaimsPrincipalAccessor : IClaimsPrincipalAccessor
    {
        private readonly AsyncLocal<ContextHolder> _context = new();

        public ClaimsPrincipal? Principal
        {
            get => _context.Value?.Context;
            set
            {
                var holder = _context.Value;
                if (holder is not null)
                {
                    holder.Context = null;
                }

                if (value is not null)
                {
                    _context.Value = new ContextHolder { Context = value };
                }
            }
        }

        private class ContextHolder
        {
            public ClaimsPrincipal? Context;
        }
    }
}