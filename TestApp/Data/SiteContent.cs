namespace TestApp.Data;

/// <summary>
/// Zentrale Inhaltsdatei der Webseite. Alle Texte und Daten der Seite werden
/// ausschließlich hier gepflegt (Quelle: Lebenslauf, Stand Juni 2026).
/// </summary>
public static class SiteContent
{
    public const string Name = "Moritz Waldau";
    public const string JobTitle = "IT-Consultant";
    public const string Tagline = "Systemarchitektur und Full-Stack-Entwicklung mit .NET und der Azure Cloud.";

    /// <summary>Rotierende Begriffe für die Typewriter-Animation im Hero („Ich gestalte …").</summary>
    public static readonly string[] TypewriterWords =
    [
        ".NET Lösungen",
        "Cloud-Anwendungen",
        "Microservices",
    ];

    public const string AboutText =
        "Ich bin IT-Consultant bei Cluster Reply in München — mit einem klaren Schwerpunkt: .NET und die Azure Cloud. " +
        "Nach meinem dualen Studium der Wirtschaftsinformatik (B.Sc.) habe ich bei Swiss Life Deutschland Anwendungen " +
        "mitbetreut, die täglich von über 13.000 Beratern genutzt werden. " +
        "Heute verantworte ich die Pflege und Weiterentwicklung einer .NET-4.8-Legacy-Applikation, treffe " +
        "Architekturentscheidungen und unterstütze den Kunden bei der Priorisierung der Epics im Migrationsprojekt " +
        "hin zu einer modernen .NET-9-MAUI-Anwendung.";

    public const string AboutTextSecondary =
        "Kunden schätzen mich als technischen Ansprechpartner, der komplexe Anforderungen schnell in tragfähige " +
        "Lösungen übersetzt. Abseits des Codes findet man mich in den Bergen — im Sommer beim Wandern, im Winter auf Skiern.";

    public static readonly IReadOnlyList<string> AboutHighlights =
    [
        "Architektur & Migration",
        "Azure & AWS",
        "13.000+ Nutzer betreut",
        "Mentoring & Wissenstransfer",
    ];

    /// <summary>Pfad relativ zu wwwroot; Datei dort ablegen oder leer lassen, dann wird ein Initialen-Avatar gezeigt.</summary>
    public const string PortraitPath = "img/portrait.jpg";

    public const string Email = "moritzwaldau99@gmail.com";
    public const string Phone = "+49 177 8905399";
    public const string GitHubUrl = "https://github.com/MoritzWaldau";
    public const string LinkedInUrl = "https://www.linkedin.com/in/moritz-waldau-0a5778238/";

    public static readonly IReadOnlyList<Stat> Stats =
    [
        new(5, "+", "Jahre Agile Softwareentwicklung", "calendar"),
        new(100, "K +", "Nutzer Anwendung betreut", "users"),
        new(5, "+", "Technologien im Stack", "layers"),
        new(2, "", "Cloud-Plattformen (AWS & Azure)", "cloud"),
    ];

    public static readonly IReadOnlyList<SkillGroup> SkillGroups =
    [
        new("Backend & Sprachen", ["C#", ".NET 4.8 – 9", ".NET MAUI", "Java 17", "Java EE", "SQL", "REST APIs"], "backend"),
        new("Frontend & Web", ["Blazor", "VueJs", "JSF", "HTML/CSS"], "frontend"),
        new("Cloud & Methoden", ["AWS", "Azure", "Microservice-Architektur", "Scrum", "Git"], "cloud"),
        new("Sprachen", ["Deutsch (Muttersprache)", "Englisch (gute Kenntnisse)"], "languages"),
    ];

    /// <summary>Eigene Open-Source-Projekte von GitHub — als große Featured-Karten dargestellt.</summary>
    public static readonly IReadOnlyList<FeaturedProject> FeaturedProjects =
    [
        new("OrderSphere",
            "Open Source · Referenzarchitektur",
            "OrderSphere ist meine Referenzarchitektur für moderne E-Commerce-Systeme: acht Microservices auf .NET 10, " +
            "konsequent nach Clean Architecture und Domain-Driven Design geschnitten, mit CQRS über MediatR und " +
            "durchgängigem Result<T>-Pattern statt Exceptions. Jeder Service bringt seine eigene PostgreSQL-Datenbank " +
            "mit; kommuniziert wird asynchron über Azure Service Bus mit Outbox/Inbox-Pattern. Dazu kommen Redis " +
            "HybridCache, ein YARP-Gateway mit BFF, Auth0-Login, OpenTelemetry und .NET Aspire für die lokale " +
            "Orchestrierung — und obendrauf ein KI-Beratungsagent mit Azure OpenAI und eigenem MCP-Server.",
            [
                "8 Microservices · Clean Architecture · DDD · CQRS",
                "Outbox/Inbox über Azure Service Bus, PostgreSQL pro Service",
                "KI-Agent mit Azure OpenAI + eigenem MCP-Server",
                "CI mit 70 % Coverage-Gate, CodeQL, Gitleaks & Trivy",
                "azd/Bicep-Deployment auf Azure Container Apps",
            ],
            [".NET 10", "Blazor WASM", "MudBlazor", "PostgreSQL", "Azure Service Bus", "Redis", "YARP", "Auth0", ".NET Aspire", "OpenTelemetry", "Azure OpenAI"],
            "https://github.com/MoritzWaldau/OrderSphere",
            "orderSphere"),
        new("EmployeeManagementSystem",
            "Open Source · Cloud-Native",
            "Entstanden als Code-Challenge bei Cluster Reply — und ausgebaut zu einer vollwertigen, cloud-nativen " +
            "Anwendung für die Mitarbeiterverwaltung. .NET 9 mit .NET Aspire als Orchestrierung, containerisiert mit " +
            "Docker, automatisiert gebaut und ausgeliefert über GitHub Actions und produktiv deployt auf Azure " +
            "Container Apps. Ein kompaktes Projekt, das zeigt, wie ich Software von der ersten Zeile bis zum " +
            "Cloud-Deployment denke.",
            [
                ".NET Aspire Orchestrierung",
                "CI/CD mit GitHub Actions",
                "Docker → Azure Container Apps",
            ],
            [".NET 9", ".NET Aspire", "Docker", "GitHub Actions", "Azure Container Apps"],
            "https://github.com/MoritzWaldau/EmployeeManagementSystem",
            "employeeManagement"),
    ];

    public static readonly IReadOnlyList<Project> Projects =
    [
        new("Legacy-Modernisierung im Automotive-Umfeld",
            "Verantwortung für die Systemarchitektur bei der Ablösung einer Legacy-.NET-4.8-Anwendung durch eine " +
            "neue .NET-9-MAUI-Lösung — inklusive Service-Grenzen, Datenflussmustern und Integrationspunkten. Als " +
            "technischer Mitansprechpartner der OEM-Kundenseite stimme ich Epic-Scopes und Akzeptanzkriterien ab.",
            ["C#", ".NET 9", ".NET MAUI", "Systemarchitektur"],
            Link: null),
        new("Beraterportale für 13.000+ Nutzer",
            "Betreuung und Weiterentwicklung zweier großer Anwendungen der Swiss Life Deutschland: neue " +
            "Backend-Lösungen in Java, Optimierung der Microservice-Architektur und Frontends mit JSF und VueJs — " +
            "inklusive Mentoring eines dualen Studenten.",
            ["Java", "Microservices", "JSF", "VueJs"],
            Link: null),
        new("Bachelorarbeit: Ausweisdaten-Extraktion mit OCR & ML",
            "Microservice zur Extraktion und Aufbereitung von Personalausweisdaten: Texterkennung mit AWS Textract, " +
            "ML-gestützte Strukturierung, Ablage in S3 und Bereitstellung über ein VueJs-Frontend — mit Fokus auf " +
            "Genauigkeit, Performance und Skalierbarkeit.",
            ["Java 17", "Java EE", "Payara", "AWS Textract", "AWS S3", "VueJs"],
            Link: null),
    ];

    public static readonly IReadOnlyList<CvEntry> Career =
    [
        new("04/2025 – heute",
            "IT-Consultant",
            "Cluster Reply, München",
            "Mitverantwortung für Systemarchitektur (Legacy .NET 4.8 → .NET 9 MAUI)," +
            "Ansprechpartner der OEM-Kundenseite, Unterstützung als Anlaufstelle für Architektur- und " +
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

    /// <summary>Kicker/Headline/Intro je Sektion — hier zentral pflegen statt in den Komponenten.</summary>
    public static class SectionCopy
    {
        public const string AboutKicker = "Wer ich bin";
        public const string AboutTitle = "Vom dualen Studium zur Systemarchitektur";

        public const string SkillsKicker = "Werkzeugkasten";
        public const string SkillsTitle = "Technologien, mit denen ich täglich baue";

        public const string ProjectsKicker = "Ausgewählte Arbeiten";
        public const string ProjectsTitle = "Projekte, hinter denen ich stehe";
        public const string ProjectsIntro = "Zwei Open-Source-Projekte aus eigenem Antrieb — und drei Stationen aus dem Projektalltag.";
        public const string ProjectsSecondaryTitle = "Aus dem Projektalltag";

        public const string TimelineKicker = "Stationen";
        public const string TimelineTitle = "Mein Weg bis hierher";

        public const string ContactKicker = "Kontakt";
        public const string ContactTitle = "Lassen Sie uns sprechen";
        public const string ContactIntro = "Sie haben ein Projekt, eine Frage oder Lust auf einen technischen Austausch? Schreiben Sie mir — ich antworte in der Regel innerhalb von 24 Stunden.";
    }
}

public sealed record SkillGroup(string Title, string[] Skills, string Icon);

public sealed record Project(string Title, string Description, string[] Technologies, string? Link);

/// <summary>Eigenes Open-Source-Projekt (GitHub) für die große Featured-Karte.</summary>
public sealed record FeaturedProject(
    string Title,
    string Kicker,
    string Description,
    string[] Highlights,
    string[] Technologies,
    string RepoUrl,
    string Graphic);

public sealed record CvEntry(string Period, string Role, string Organization, string Description);

/// <summary>Kennzahl für die animierte Stats-Leiste (Zähler zählt bis <paramref name="Value"/> hoch).</summary>
public sealed record Stat(int Value, string Suffix, string Label, string Icon);
