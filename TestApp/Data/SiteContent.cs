namespace TestApp.Data;

/// <summary>
/// Zentrale Inhaltsdatei der Webseite. Sprachunabhängige Fakten (Name, Kontaktdaten)
/// stehen als statische Member zur Verfügung; übersetzbarer Inhalt liegt in
/// <see cref="Content"/> und wird über <see cref="Current"/>/<see cref="SetLanguage"/>
/// umgeschaltet (Quelle: Lebenslauf, Stand Juni 2026).
/// </summary>
public static class SiteContent
{
    public const string Name = "Moritz Waldau";

    /// <summary>Pfad relativ zu wwwroot; Datei dort ablegen oder leer lassen, dann wird ein Initialen-Avatar gezeigt.</summary>
    public const string PortraitPath = "img/portrait.jpg";

    public const string Email = "moritzwaldau99@gmail.com";
    public const string GitHubUrl = "https://github.com/MoritzWaldau";
    public const string LinkedInUrl = "https://www.linkedin.com/in/moritz-waldau-0a5778238/";

    /// <summary>Aktuell aktive Sprachversion. Default Deutsch.</summary>
    public static Content Current { get; private set; } = Content.German;

    /// <summary>Feuert, wenn sich <see cref="Current"/> ändert — Komponenten abonnieren dies für Re-Render.</summary>
    public static event Action? LanguageChanged;

    public static bool IsEnglish => Current == Content.English;

    public static void SetLanguage(bool english)
    {
        var next = english ? Content.English : Content.German;
        if (Current == next)
        {
            return;
        }

        Current = next;
        LanguageChanged?.Invoke();
    }

    /// <summary>True, sobald der Wert kein [PLATZHALTER] mehr ist — Komponenten blenden unausgefüllte Teile aus.</summary>
    public static bool IsProvided(string value) => !value.StartsWith("[PLATZHALTER", StringComparison.Ordinal);

    /// <summary>Bleibt bewusst Deutsch-only (Impressumspflicht nach § 5 DDG).</summary>
    public static class Impressum
    {
        public const string FullName = Name;
        public const string Street = "Schwarmstedter Str. 2";
        public const string City = "29690 Essel";
    }
}

/// <summary>Übersetzbare Inhalte einer Sprachversion der Seite.</summary>
public sealed record Content(
    string JobTitle,
    string Tagline,
    string[] TypewriterWords,
    string AboutText,
    string AboutTextSecondary,
    IReadOnlyList<string> AboutHighlights,
    IReadOnlyList<Stat> Stats,
    IReadOnlyList<SkillGroup> SkillGroups,
    IReadOnlyList<FeaturedProject> FeaturedProjects,
    IReadOnlyList<Project> Projects,
    IReadOnlyList<CvEntry> Career,
    SectionCopyContent SectionCopy,
    ChromeCopyContent Chrome)
{
    public static readonly Content German = new(
        JobTitle: "IT-Consultant",
        Tagline: "Systemarchitektur und Full-Stack-Entwicklung mit .NET und der Azure Cloud.",
        TypewriterWords: [".NET Lösungen", "Cloud-Anwendungen", "Microservices", "AI Agents"],
        AboutText:
            "Ich bin IT-Consultant bei Cluster Reply in München — mit einem klaren Schwerpunkt: .NET und die Azure Cloud. " +
            "Nach meinem dualen Studium der Wirtschaftsinformatik (B.Sc.) habe ich bei Swiss Life Deutschland Anwendungen " +
            "mitbetreut, die täglich von über 13.000 Beratern genutzt werden. " +
            "Heute verantworte ich die Pflege und Weiterentwicklung einer .NET-4.8-Legacy-Applikation, treffe " +
            "Architekturentscheidungen und unterstütze den Kunden bei der Priorisierung der Epics im Migrationsprojekt " +
            "hin zu einer modernen .NET-9-MAUI-Anwendung.",
        AboutTextSecondary:
            "KI-gestützte Entwicklung ist dabei fester Teil meines Alltags: Ich arbeite täglich mit Claude Code und " +
            "GitHub Copilot, baue AI Agents und eigene MCP-Server und verfolge die Entwicklungen im Agentic-Umfeld " +
            "aus erster Hand. Kunden schätzen mich als technischen Ansprechpartner, der komplexe Anforderungen schnell " +
            "in tragfähige Lösungen übersetzt. Abseits des Codes findet man mich in den Bergen — im Sommer beim " +
            "Wandern, im Winter auf Skiern.",
        AboutHighlights:
        [
            "Architektur & Migration",
            "Azure & AWS",
            "AI Agents & MCP",
            "13.000+ Nutzer betreut",
            "Mentoring & Wissenstransfer",
        ],
        Stats:
        [
            new(5, "+", "Jahre Agile Softwareentwicklung", "calendar"),
            new(100, "K +", "Nutzer Anwendung betreut", "users"),
            new(5, "+", "Technologien im Stack", "layers"),
            new(2, "", "Cloud-Plattformen (AWS & Azure)", "cloud"),
        ],
        SkillGroups:
        [
            new("Backend & Sprachen", ["C#", ".NET 4.8 – 10", ".NET MAUI", "Java 17", "Java EE", "SQL", "REST APIs"], "backend"),
            new("Frontend & Web", ["Blazor", "VueJs", "JSF", "HTML/CSS"], "frontend"),
            new("KI & Agentic Development", ["MCP (Model Context Protocol)", "AI Agents", "Claude Code", "GitHub Copilot", "Azure OpenAI"], "ai"),
            new("Cloud & Methoden", ["AWS", "Azure", "Microservice-Architektur", "Scrum", "Git"], "cloud"),
            new("Sprachen", ["Deutsch (Muttersprache)", "Englisch (gute Kenntnisse)"], "languages"),
        ],
        FeaturedProjects:
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
                "orderSphere",
                "ordersphere"),
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
                "employeeManagement",
                "employeemanagementsystem"),
        ],
        Projects:
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
        ],
        Career:
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
        ],
        SectionCopy: new(
            AboutKicker: "Wer ich bin",
            AboutTitle: "Vom dualen Studium zur Systemarchitektur",
            SkillsKicker: "Werkzeugkasten",
            SkillsTitle: "Technologien",
            ProjectsKicker: "Ausgewählte Arbeiten",
            ProjectsTitle: "Projekte",
            ProjectsIntro: "Zwei Open-Source-Projekte aus eigenem Antrieb — und drei Stationen aus dem Projektalltag.",
            ProjectsSecondaryTitle: "Aus dem Projektalltag",
            TimelineKicker: "Stationen",
            TimelineTitle: "Mein Weg bis hierher",
            ContactKicker: "Kontakt",
            ContactTitle: "Lassen Sie uns sprechen",
            ContactIntro: "Sie haben ein Projekt, eine Frage oder Lust auf einen technischen Austausch? Schreiben Sie mir eine E-Mail — ich melde mich in der Regel innerhalb von 24 Stunden zurück."),
        Chrome: new(
            NavAbout: "Über mich",
            NavSkills: "Skills",
            NavProjects: "Projekte",
            NavCareer: "Werdegang",
            NavContact: "Kontakt",
            SkipLink: "Zum Inhalt springen",
            BackToTopLabel: "Nach oben scrollen",
            FooterSitemapHeading: "Sitemap",
            FooterLegalHeading: "Rechtliches & Social",
            ImpressumLabel: "Impressum",
            DatenschutzLabel: "Datenschutz",
            FooterBuiltWith: "Gebaut mit Blazor WebAssembly & ☕ — gehostet auf GitHub Pages",
            NotFoundTitle: "Diese Seite ist im Deployment verloren gegangen.",
            NotFoundLead: "Die gesuchte Seite existiert leider nicht.",
            NotFoundHome: "Zur Startseite",
            NotFoundProjects: "Zu den Projekten",
            HeroLeadIn: "Ich gestalte",
            HeroCtaContact: "Kontakt aufnehmen",
            HeroCtaProjects: "Projekte ansehen",
            ViewOnGitHub: "Auf GitHub ansehen",
            ViewProject: "Zum Projekt",
            CurrentBadge: "Aktuell",
            GitHubUpdatedToday: "heute aktualisiert",
            GitHubUpdatedDaysAgo: "vor {0} Tagen aktualisiert",
            ProjectDetailBack: "← Zurück zu den Projekten",
            ProjectDetailHighlights: "Highlights",
            ProjectDetailTechStack: "Tech-Stack",
            ProjectDetailMore: "Mehr erfahren",
            CmdkPlaceholder: "Suchen oder Befehl eingeben…",
            CmdkNoResults: "Keine Treffer",
            CmdkSectionNav: "Navigation",
            CmdkSectionProjects: "Projekte",
            CmdkSectionActions: "Aktionen",
            CmdkHint: "↑↓ navigieren · ↵ öffnen · Esc schließen"));

    public static readonly Content English = new(
        JobTitle: "IT Consultant",
        Tagline: "System architecture and full-stack development with .NET and the Azure Cloud.",
        TypewriterWords: [".NET Solutions", "Cloud Applications", "Microservices", "AI Agents"],
        AboutText:
            "I'm an IT Consultant at Cluster Reply in Munich — with a clear focus: .NET and the Azure Cloud. " +
            "After completing my dual studies in Business Informatics (B.Sc.), I helped maintain applications at " +
            "Swiss Life Germany that are used daily by more than 13,000 advisors. " +
            "Today I'm responsible for maintaining and evolving a legacy .NET 4.8 application, make architecture " +
            "decisions, and support the client in prioritizing epics for the migration project toward a modern " +
            ".NET 9 MAUI application.",
        AboutTextSecondary:
            "AI-assisted development is a core part of my daily work: I code with Claude Code and GitHub Copilot " +
            "every day, build AI agents and custom MCP servers, and follow the agentic ecosystem first-hand. " +
            "Clients value me as a technical point of contact who translates complex requirements into robust " +
            "solutions quickly. Away from the keyboard you'll find me in the mountains — hiking in summer, skiing in winter.",
        AboutHighlights:
        [
            "Architecture & Migration",
            "Azure & AWS",
            "AI Agents & MCP",
            "13,000+ Users Supported",
            "Mentoring & Knowledge Transfer",
        ],
        Stats:
        [
            new(5, "+", "Years of Agile Software Development", "calendar"),
            new(100, "K +", "Users of Applications Maintained", "users"),
            new(5, "+", "Technologies in the Stack", "layers"),
            new(2, "", "Cloud Platforms (AWS & Azure)", "cloud"),
        ],
        SkillGroups:
        [
            new("Backend & Languages", ["C#", ".NET 4.8 – 10", ".NET MAUI", "Java 17", "Java EE", "SQL", "REST APIs"], "backend"),
            new("Frontend & Web", ["Blazor", "VueJs", "JSF", "HTML/CSS"], "frontend"),
            new("AI & Agentic Development", ["MCP (Model Context Protocol)", "AI Agents", "Claude Code", "GitHub Copilot", "Azure OpenAI"], "ai"),
            new("Cloud & Methods", ["AWS", "Azure", "Microservice Architecture", "Scrum", "Git"], "cloud"),
            new("Languages", ["German (Native)", "English (Proficient)"], "languages"),
        ],
        FeaturedProjects:
        [
            new("OrderSphere",
                "Open Source · Reference Architecture",
                "OrderSphere is my reference architecture for modern e-commerce systems: eight microservices on " +
                ".NET 10, consistently structured around Clean Architecture and Domain-Driven Design, with CQRS via " +
                "MediatR and a consistent Result<T> pattern instead of exceptions. Each service brings its own " +
                "PostgreSQL database; communication happens asynchronously via Azure Service Bus with an outbox/inbox " +
                "pattern. On top of that: Redis HybridCache, a YARP gateway with BFF, Auth0 login, OpenTelemetry, and " +
                ".NET Aspire for local orchestration — plus an AI advisory agent powered by Azure OpenAI and its own MCP server.",
                [
                    "8 Microservices · Clean Architecture · DDD · CQRS",
                    "Outbox/Inbox via Azure Service Bus, PostgreSQL per Service",
                    "AI Agent with Azure OpenAI + Custom MCP Server",
                    "CI with 70% Coverage Gate, CodeQL, Gitleaks & Trivy",
                    "azd/Bicep Deployment on Azure Container Apps",
                ],
                [".NET 10", "Blazor WASM", "MudBlazor", "PostgreSQL", "Azure Service Bus", "Redis", "YARP", "Auth0", ".NET Aspire", "OpenTelemetry", "Azure OpenAI"],
                "https://github.com/MoritzWaldau/OrderSphere",
                "orderSphere",
                "ordersphere"),
            new("EmployeeManagementSystem",
                "Open Source · Cloud-Native",
                "Started as a code challenge at Cluster Reply — and expanded into a full cloud-native application " +
                "for employee management. .NET 9 with .NET Aspire for orchestration, containerized with Docker, " +
                "built and shipped automatically via GitHub Actions, and deployed to production on Azure Container " +
                "Apps. A compact project that shows how I think about software from the first line of code to cloud deployment.",
                [
                    ".NET Aspire Orchestration",
                    "CI/CD with GitHub Actions",
                    "Docker → Azure Container Apps",
                ],
                [".NET 9", ".NET Aspire", "Docker", "GitHub Actions", "Azure Container Apps"],
                "https://github.com/MoritzWaldau/EmployeeManagementSystem",
                "employeeManagement",
                "employeemanagementsystem"),
        ],
        Projects:
        [
            new("Legacy Modernization in the Automotive Sector",
                "Responsible for the system architecture behind replacing a legacy .NET 4.8 application with a new " +
                ".NET 9 MAUI solution — including service boundaries, data flow patterns, and integration points. As " +
                "a technical point of contact for the OEM customer side, I align epic scopes and acceptance criteria.",
                ["C#", ".NET 9", ".NET MAUI", "System Architecture"],
                Link: null),
            new("Advisor Portals for 13,000+ Users",
                "Maintained and evolved two large applications at Swiss Life Germany: new backend solutions in Java, " +
                "optimization of the microservice architecture, and frontends with JSF and VueJs — including " +
                "mentoring a work-study student.",
                ["Java", "Microservices", "JSF", "VueJs"],
                Link: null),
            new("Bachelor's Thesis: ID Data Extraction with OCR & ML",
                "Microservice for extracting and processing ID card data: text recognition with AWS Textract, " +
                "ML-assisted data structuring, storage in S3, and delivery via a VueJs frontend — with a focus on " +
                "accuracy, performance, and scalability.",
                ["Java 17", "Java EE", "Payara", "AWS Textract", "AWS S3", "VueJs"],
                Link: null),
        ],
        Career:
        [
            new("04/2025 – Present",
                "IT Consultant",
                "Cluster Reply, Munich",
                "Co-responsible for system architecture (legacy .NET 4.8 → .NET 9 MAUI), point of contact for the " +
                "OEM customer side, supporting as a go-to resource for architecture and implementation questions."),
            new("09/2024 – 03/2025",
                "Full Stack Software Engineer (Java)",
                "Swiss Life Deutschland Operations GmbH, Hanover",
                "Maintained two applications with over 13,000 users, backend development in Java, optimization of " +
                "the microservice architecture, frontends with JSF and VueJs, mentored a work-study student and an " +
                "external colleague."),
            new("09/2021 – 08/2024",
                "Dual Studies in Business Informatics (B.Sc. 2024)",
                "Swiss Life Deutschland / Leibniz University of Applied Sciences, Hanover",
                "Practical phases in application development (Java, microservices, VueJs); studies focused on " +
                "software architecture, databases, and AI-assisted development processes. Degree: Bachelor of Science."),
            new("08/2019 – 07/2020",
                "IT Internship",
                "Swiss Life Deutschland Operations GmbH, Hanover",
                "IT administration of laptops and mobile devices, support and troubleshooting for technical issues."),
            new("2021",
                "University Entrance Qualification, Business & IT",
                "Dr. Buhmann Schule & Akademie, Hanover",
                "Focus areas: computer science, business, and project management."),
        ],
        SectionCopy: new(
            AboutKicker: "Who I Am",
            AboutTitle: "From Dual Studies to System Architecture",
            SkillsKicker: "Toolbox",
            SkillsTitle: "Technologies",
            ProjectsKicker: "Selected Work",
            ProjectsTitle: "Projects",
            ProjectsIntro: "Two open-source projects built on my own initiative — and three highlights from day-to-day project work.",
            ProjectsSecondaryTitle: "From Day-to-Day Project Work",
            TimelineKicker: "Milestones",
            TimelineTitle: "My Path So Far",
            ContactKicker: "Contact",
            ContactTitle: "Let's Talk",
            ContactIntro: "Have a project, a question, or fancy a technical exchange? Send me an email — I usually get back to you within 24 hours."),
        Chrome: new(
            NavAbout: "About",
            NavSkills: "Skills",
            NavProjects: "Projects",
            NavCareer: "Career",
            NavContact: "Contact",
            SkipLink: "Skip to content",
            BackToTopLabel: "Scroll to top",
            FooterSitemapHeading: "Sitemap",
            FooterLegalHeading: "Legal & Social",
            ImpressumLabel: "Imprint (German)",
            DatenschutzLabel: "Privacy Policy (German)",
            FooterBuiltWith: "Built with Blazor WebAssembly & ☕ — hosted on GitHub Pages",
            NotFoundTitle: "This page got lost somewhere in the deployment.",
            NotFoundLead: "Sorry, the page you're looking for doesn't exist.",
            NotFoundHome: "Back to Home",
            NotFoundProjects: "View Projects",
            HeroLeadIn: "I build",
            HeroCtaContact: "Get in Touch",
            HeroCtaProjects: "View Projects",
            ViewOnGitHub: "View on GitHub",
            ViewProject: "View Project",
            CurrentBadge: "Current",
            GitHubUpdatedToday: "updated today",
            GitHubUpdatedDaysAgo: "updated {0} days ago",
            ProjectDetailBack: "← Back to Projects",
            ProjectDetailHighlights: "Highlights",
            ProjectDetailTechStack: "Tech Stack",
            ProjectDetailMore: "Learn more",
            CmdkPlaceholder: "Search or type a command…",
            CmdkNoResults: "No results",
            CmdkSectionNav: "Navigation",
            CmdkSectionProjects: "Projects",
            CmdkSectionActions: "Actions",
            CmdkHint: "↑↓ navigate · ↵ open · Esc close"));
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
    string Graphic,
    string Slug);

public sealed record CvEntry(string Period, string Role, string Organization, string Description);

/// <summary>Kennzahl für die animierte Stats-Leiste (Zähler zählt bis <paramref name="Value"/> hoch).</summary>
public sealed record Stat(int Value, string Suffix, string Label, string Icon);

/// <summary>Kicker/Headline/Intro je Sektion — hier zentral pflegen statt in den Komponenten.</summary>
public sealed record SectionCopyContent(
    string AboutKicker,
    string AboutTitle,
    string SkillsKicker,
    string SkillsTitle,
    string ProjectsKicker,
    string ProjectsTitle,
    string ProjectsIntro,
    string ProjectsSecondaryTitle,
    string TimelineKicker,
    string TimelineTitle,
    string ContactKicker,
    string ContactTitle,
    string ContactIntro);

/// <summary>Nav-/Footer-/Rahmen-Texte, die außerhalb der Sektionen liegen.</summary>
public sealed record ChromeCopyContent(
    string NavAbout,
    string NavSkills,
    string NavProjects,
    string NavCareer,
    string NavContact,
    string SkipLink,
    string BackToTopLabel,
    string FooterSitemapHeading,
    string FooterLegalHeading,
    string ImpressumLabel,
    string DatenschutzLabel,
    string FooterBuiltWith,
    string NotFoundTitle,
    string NotFoundLead,
    string NotFoundHome,
    string NotFoundProjects,
    string HeroLeadIn,
    string HeroCtaContact,
    string HeroCtaProjects,
    string ViewOnGitHub,
    string ViewProject,
    string CurrentBadge,
    string GitHubUpdatedToday,
    string GitHubUpdatedDaysAgo,
    string ProjectDetailBack,
    string ProjectDetailHighlights,
    string ProjectDetailTechStack,
    string ProjectDetailMore,
    string CmdkPlaceholder,
    string CmdkNoResults,
    string CmdkSectionNav,
    string CmdkSectionProjects,
    string CmdkSectionActions,
    string CmdkHint);
