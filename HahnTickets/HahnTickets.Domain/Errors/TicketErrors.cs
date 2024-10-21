using ErrorOr;

namespace HahnTickets.Shared.Errors
{
    public static class TicketErrors
    {
        public static Error NotFound => Error.NotFound(
            code: "Ticket.NotFound",
            description: "No Ticket with this Id.");
        public static Error CannotSave => Error.Validation(
            code: "Ticket.ValidationIssues",
            description: "description and status is required"
            );
    }
}
