namespace CoreDetails
{
    public class PrintToScreenData
    {
        /// <summary>
        /// Gets the print text.
        /// </summary>
        /// <value>The print text.</value>
        public string PrintText { get; }
        /// <summary>
        /// Gets the number of times to print the text.
        /// </summary>
        /// <value>The repeats.</value>
        public uint Repeats { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintToScreenData"/> class.
        /// Defaults PrintText property to empty string when printText param is null.
        /// Defaults Repeats property to 1 if repeats param is 0.
        /// </summary>
        /// <param name="printText">The print text.</param>
        /// <param name="repeats">The repeats.</param>
        public PrintToScreenData(string printText, uint repeats)
        {
            PrintText = printText ?? string.Empty;
            Repeats = repeats == 0 ? 1 : repeats;
        }
    }
}