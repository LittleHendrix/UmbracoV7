// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuceneHighlightHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The lucene highlight helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Infrastructure
{
    using System.Collections.Generic;
    using System.IO;

    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Highlight;
    using Lucene.Net.QueryParsers;
    using Lucene.Net.Search;
    using Lucene.Net.Util;

    /// <summary>
    /// The lucene highlight helper.
    /// </summary>
    public class LuceneHighlightHelper
    {
        #region Static Fields

        /// <summary>
        /// The lucene instance.
        /// </summary>
        // private static readonly LuceneHighlightHelper LuceneInstance = new LuceneHighlightHelper();

        #endregion

        #region Fields

        /// <summary>
        /// The lucene version.
        /// </summary>
        private readonly Version luceneVersion = Version.LUCENE_29;

        /// <summary>
        /// The query parsers.
        /// </summary>
        private readonly Dictionary<string, QueryParser> queryParsers = new Dictionary<string, QueryParser>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Prevents a default instance of the <see cref="LuceneHighlightHelper"/> class from being created.
        /// </summary>
        private LuceneHighlightHelper()
        {
            this.Separator = "...";
            this.MaxNumHighlights = 3;
            this.HighlightAnalyzer = new StandardAnalyzer(this.luceneVersion);
            this.HighlightFormatter = new SimpleHTMLFormatter(string.Empty, " ");
        }

        #endregion

        #region Public Properties

        public static LuceneHighlightHelper Instance
        {
            get
            {
                return Nested.LuceneInstance;
            }
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly LuceneHighlightHelper LuceneInstance = new LuceneHighlightHelper();
        }

        /// <summary>
        /// Gets or sets the highlight analyzer.
        /// </summary>
        public Analyzer HighlightAnalyzer { get; set; }

        /// <summary>
        /// Gets or sets the highlight formatter.
        /// </summary>
        public Formatter HighlightFormatter { get; set; }

        /// <summary>
        /// Gets or sets the max num highlights.
        /// </summary>
        public int MaxNumHighlights { get; set; }

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        public string Separator { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get highlight.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="highlightField">
        /// The highlight field.
        /// </param>
        /// <param name="searcher">
        /// The searcher.
        /// </param>
        /// <param name="luceneRawQuery">
        /// The lucene raw query.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetHighlight(string value, string highlightField, Searcher searcher, string luceneRawQuery)
        {
            Query query = this.GetQueryParser(highlightField).Parse(luceneRawQuery);
            var scorer = new QueryScorer(searcher.Rewrite(query));

            var highlighter = new Highlighter(this.HighlightFormatter, scorer);

            TokenStream tokenStream = this.HighlightAnalyzer.TokenStream(highlightField, new StringReader(value));
            return highlighter.GetBestFragments(tokenStream, value, this.MaxNumHighlights, this.Separator);
        }

        /// <summary>
        /// The get highlight.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="highlightField">
        /// The highlight field.
        /// </param>
        /// <param name="searcher">
        /// The searcher.
        /// </param>
        /// <param name="luceneRawQuery">
        /// The lucene raw query.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetHighlight(string value, string highlightField, IndexSearcher searcher, string luceneRawQuery)
        {
            Query query = this.GetQueryParser(highlightField).Parse(luceneRawQuery);
            var scorer = new QueryScorer(query.Rewrite(searcher.GetIndexReader()));

            var highlighter = new Highlighter(this.HighlightFormatter, scorer);

            TokenStream tokenStream = this.HighlightAnalyzer.TokenStream(highlightField, new StringReader(value));
            return highlighter.GetBestFragments(tokenStream, value, this.MaxNumHighlights, this.Separator);
        }

        /// <summary>
        /// The get highlight.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="searcher">
        /// The searcher.
        /// </param>
        /// <param name="highlightField">
        /// The highlight field.
        /// </param>
        /// <param name="luceneQuery">
        /// The lucene query.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetHighlight(string value, IndexSearcher searcher, string highlightField, Query luceneQuery)
        {
            var scorer = new QueryScorer(luceneQuery.Rewrite(searcher.GetIndexReader()));
            var highlighter = new Highlighter(this.HighlightFormatter, scorer);

            TokenStream tokenStream = this.HighlightAnalyzer.TokenStream(highlightField, new StringReader(value));
            return highlighter.GetBestFragments(tokenStream, value, this.MaxNumHighlights, this.Separator);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get query parser.
        /// </summary>
        /// <param name="highlightField">
        /// The highlight field.
        /// </param>
        /// <returns>
        /// The <see cref="QueryParser"/>.
        /// </returns>
        protected QueryParser GetQueryParser(string highlightField)
        {
            if (!this.queryParsers.ContainsKey(highlightField))
            {
                this.queryParsers[highlightField] = new QueryParser(
                    this.luceneVersion, 
                    highlightField, 
                    this.HighlightAnalyzer);
            }

            return this.queryParsers[highlightField];
        }

        #endregion
    }
}