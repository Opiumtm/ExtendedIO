namespace Ipatov.CoreDb.Core.WriteAhead
{
    /// <summary>
    /// Write-ahead pages logged.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="pages">Logged pages.</param>
    public delegate void WriteAheadLogged(object sender, WriteAheadLogData[] pages);
}