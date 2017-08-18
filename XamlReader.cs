public WorkflowService ToWorkflowService(string value)
        {
            WorkflowService service = null;

            // 1. assume value is Xaml
            string xaml = value;

            // 2. if value is file path,
            if (File.Exists(value))
            {
                // 2a. read contents to xaml
                xaml = File.ReadAllText(value);
            }

            // 3. build service
            using (StringReader xamlReader = new StringReader(xaml))
            {
                object untypedService = null;

                // NOTE: XamlServices, NOT ActivityXamlServices
                untypedService = XamlServices.Load(xamlReader);

                if (untypedService is WorkflowService)
                {
                    service = (WorkflowService)(untypedService);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                        "Unexpected error reading WorkflowService from " +
                        "value [{0}] and Xaml [{1}]. Xaml does not define a " +
                        "WorkflowService, but an instance of [{2}].",
                        value,
                        xaml,
                        untypedService.GetType()));
                }
            }

            return service;
        }


