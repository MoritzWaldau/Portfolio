namespace TestApp.Data;

/// <summary>
/// Zentrale Inhaltsdatei der Webseite. Alle Texte und Daten der Seite werden
/// ausschließlich hier gepflegt (Quelle: Lebenslauf, Stand Juni 2026).
/// </summary>
public static class SiteContent
{
    public const string Name = "Moritz Waldau";
    public const string JobTitle = "IT-Consultant";
    public const string Tagline = "Systemarchitektur und Full-Stack-Entwicklung mit .NET, Java und der Cloud.";

    /// <summary>Rotierende Begriffe für die Typewriter-Animation im Hero („Ich gestalte …").</summary>
    public static readonly string[] TypewriterWords =
    [
        "Systemarchitektur",
        ".NET- & Java-Lösungen",
        "Cloud-Anwendungen",
        "Microservices",
    ];

    public const string AboutText =
        "Ich bin IT-Consultant bei Cluster Reply in München mit Schwerpunkt auf Systemarchitektur " +
        "und Full-Stack-Entwicklung. Nach meinem dualen Studium der Wirtschaftsinformatik (B.Sc.) " +
        "habe ich bei Swiss Life Anwendungen mitbetreut, die von über 13.000 Beratern genutzt werden — " +
        "heute verantworte ich Architektur-Entscheidungen an der Schnittstelle zwischen Legacy-.NET " +
        "und modernen .NET-9/MAUI-Stacks. Kunden schätzen mich als technischen Ansprechpartner, der " +
        "komplexe Anforderungen schnell in tragfähige Lösungen übersetzt. Abseits des Codes findet " +
        "man mich in den Bergen — im Sommer beim Wandern, im Winter auf Skiern — oder beim Sport.";

    /// <summary>Pfad relativ zu wwwroot; Datei dort ablegen oder leer lassen, dann wird ein Initialen-Avatar gezeigt.</summary>
    public const string PortraitPath = "img/portrait.jpg";

    public const string Email = "moritzwaldau99@gmail.com";
    public const string Phone = "+49 177 8905399";
    public const string GitHubUrl = "[PLATZHALTER: GitHub-URL]";
    public const string LinkedInUrl = "[PLATZHALTER: LinkedIn-URL]";

    public static readonly IReadOnlyList<Stat> Stats =
    [
        new(5, "+", "Jahre IT-Erfahrung"),
        new(13000, "+", "Nutzer der betreuten Anwendungen"),
        new(10, "+", "Technologien im Stack"),
        new(2, "", "Cloud-Plattformen (AWS & Azure)"),
    ];

    public static readonly IReadOnlyList<SkillGroup> SkillGroups =
    [
        new("Backend & Sprachen", ["C#", ".NET 4.8 – 9", ".NET MAUI", "Java 17", "Java EE", "SQL", "REST APIs"]),
        new("Frontend & Web", ["Blazor", "VueJs", "JSF", "HTML/CSS"]),
        new("Cloud & Methoden", ["AWS (Textract, S3)", "Azure", "Microservice-Architektur", "Scrum", "Git"]),
        new("Sprachen", ["Deutsch (Muttersprache)", "Englisch (gute Kenntnisse)"]),
    ];

    public static readonly IReadOnlyList<Project> Projects =
    [
        new("Legacy-Modernisierung im Automotive-Umfeld",
            "Verantwortung für die Systemarchitektur bei der Ablösung einer Legacy-.NET-4.8-Anwendung " +
            "durch eine neue .NET-9-MAUI-Lösung: Definition von Service-Grenzen, Datenflussmustern und " +
            "Integrationspunkten. Als technischer Ansprechpartner der OEM-Kundenseite stimme ich " +
            "Epic-Scopes, Feature-Prioritäten und Akzeptanzkriterien ab.",
            ["C#", ".NET 9", ".NET MAUI", "Systemarchitektur"],
            Link: null),
        new("Beraterportale für 13.000+ Nutzer",
            "Betreuung und Weiterentwicklung zweier großer Anwendungen der Swiss Life Deutschland, " +
            "die von über 13.000 Beratern genutzt werden: neue Backend-Lösungen in Java, Optimierung " +
            "der Microservice-Architektur und benutzerfreundliche Frontends mit JSF und VueJs — " +
            "inklusive Mentoring eines dualen Studenten.",
            ["Java", "Microservices", "JSF", "VueJs"],
            Link: null),
        new("Bachelorarbeit: Ausweisdaten-Extraktion mit OCR & ML",
            "Entwicklung eines Microservices zur Extraktion und Aufbereitung von Personalausweisdaten: " +
            "Texterkennung mit AWS Textract, ML-gestützte Strukturierung der Daten, Ablage in S3 und " +
            "Bereitstellung über ein VueJs-Frontend — mit Fokus auf Genauigkeit, Performance und " +
            "Skalierbarkeit.",
            ["Java 17", "Java EE", "Payara", "AWS Textract", "AWS S3", "VueJs"],
            Link: null),
    ];

    public static readonly IReadOnlyList<CvEntry> Career =
    [
        new("04/2025 – heute",
            "IT-Consultant",
            "Cluster Reply, München",
            "Verantwortung für Systemarchitektur (Legacy .NET 4.8 → .NET 9 MAUI), technischer " +
            "Ansprechpartner der OEM-Kundenseite, zentrale Anlaufstelle für Architektur- und " +
            "Implementierungsfragen."),
        new("09/2024 – 03/2025",
            "Full Stack Software Engineer (Java)",
            "Swiss Life Deutschland Operations GmbH, Hannover",
            "Betreuung zweier Anwendungen mit über 13.000 Nutzern, Backend-Entwicklung in Java, " +
            "Optimierung der Microservice-Architektur, Frontends mit JSF und VueJs, Mentoring eines " +
            "dualen Studenten und eines externen Kollegen."),
        new("09/2021 – 08/2024",
            "Duales Studium Wirtschaftsinformatik (B.Sc. 2024)",
            "Swiss Life Deutschland / Leibniz-Fachhochschule, Hannover",
            "Praxisphasen in der Anwendungsentwicklung (Java, Microservices, VueJs); Studium mit " +
            "Schwerpunkten Software-Architektur, Datenbanken und KI-gestützte Entwicklungsprozesse. " +
            "Abschluss: Bachelor of Science."),
        new("08/2019 – 07/2020",
            "IT-Praktikum",
            "Swiss Life Deutschland Operations GmbH, Hannover",
            "IT-Administration von Laptops und Mobilgeräten, Support und Problemlösung bei " +
            "technischen Herausforderungen."),
        new("2021",
            "Fachhochschulreife Wirtschaft & Informatik",
            "Dr. Buhmann Schule & Akademie, Hannover",
            "Schwerpunkte Informatik, Wirtschaft und Projektmanagement."),
    ];

    /// <summary>True, sobald der Wert kein [PLATZHALTER] mehr ist — Komponenten blenden unausgefüllte Teile aus.</summary>
    public static bool IsProvided(string value) => !value.StartsWith("[PLATZHALTER", StringComparison.Ordinal);

    public static class Impressum
    {
        public const string FullName = Name;
        public const string Street = "Schwarmstedter Str. 2";
        public const string City = "29690 Essel";
        public const string Phone = SiteContent.Phone;
    }
}

public sealed record SkillGroup(string Title, string[] Skills);

public sealed record Project(string Title, string Description, string[] Technologies, string? Link);

public sealed record CvEntry(string Period, string Role, string Organization, string Description);

/// <summary>Kennzahl für die animierte Stats-Leiste (Zähler zählt bis <paramref name="Value"/> hoch).</summary>
public sealed record Stat(int Value, string Suffix, string Label);
