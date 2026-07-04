using Microsoft.AspNetCore.Components;

namespace TestApp.Components;

/// <summary>
/// Dekorative Architektur-Grafiken für die Featured-Projekte. Als eigene Klasse ausgelagert,
/// damit sowohl <see cref="ProjectsSection"/> als auch die Projekt-Detailseite sie nutzen können.
/// Die &lt;title&gt;-Elemente in der OrderSphere-Grafik zeigen beim Hover den echten Servicenamen
/// als native Browser-Tooltip (kein zusätzliches CSS/JS nötig).
/// </summary>
public static class ProjectGraphics
{
    public static MarkupString Render(string kind) => new(kind switch
    {
        "orderSphere" =>
            """
            <svg viewBox="0 0 320 220" width="100%" height="220">
                <path class="link" d="M60 110 L140 60 M60 110 L140 110 M60 110 L140 160" />
                <path class="link" d="M140 60 L240 40 M140 60 L240 90 M140 110 L240 90 M140 110 L240 130 M140 160 L240 130 M140 160 L240 180" />
                <rect class="node" x="30" y="90" width="60" height="40" rx="8"><title>Ordering</title></rect>
                <rect class="node" x="110" y="42" width="60" height="36" rx="8"><title>Catalog</title></rect>
                <rect class="node" x="110" y="92" width="60" height="36" rx="8"><title>Basket</title></rect>
                <rect class="node" x="110" y="142" width="60" height="36" rx="8"><title>Payment</title></rect>
                <circle class="pulse" cx="240" cy="40" r="7"><title>UserProfile</title></circle>
                <circle class="pulse" cx="240" cy="90" r="7"><title>Webhooks</title></circle>
                <circle class="pulse" cx="240" cy="130" r="7"><title>Notification</title></circle>
                <circle class="pulse" cx="240" cy="180" r="7"><title>Advisory</title></circle>
            </svg>
            """,
        "employeeManagement" =>
            """
            <svg viewBox="0 0 320 140" width="100%" height="140">
                <path class="link" d="M55 70 L115 70 M170 70 L230 70 M285 70 L285 70" />
                <path class="link" d="M55 70 H285" />
                <rect class="node" x="15" y="45" width="80" height="50" rx="8" />
                <rect class="node" x="130" y="45" width="80" height="50" rx="8" />
                <rect class="node" x="245" y="45" width="60" height="50" rx="8" />
                <circle class="pulse" cx="112" cy="70" r="6" />
                <circle class="pulse" cx="227" cy="70" r="6" />
            </svg>
            """,
        _ => "",
    });
}
