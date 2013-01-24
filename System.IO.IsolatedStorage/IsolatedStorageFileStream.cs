using System.Threading;
using System.Threading.Tasks;

namespace System.IO.IsolatedStorage
{
    public class IsolatedStorageFileStream : Stream
    {
        Stream stream;

        internal IsolatedStorageFileStream(Stream stream)
        {
            this.stream = stream;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                stream.Dispose();
            base.Dispose(disposing);
        }

        public override bool CanRead
        {
            get { return stream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return stream.CanWrite; }
        }

        //
        // Summary:
        //     Gets or sets a value, in miliseconds, that determines how long the stream
        //     will attempt to read before timing out.
        //
        // Returns:
        //     A value, in miliseconds, that determines how long the stream will attempt
        //     to read before timing out.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The System.IO.Stream.ReadTimeout method always throws an System.InvalidOperationException.
        public override int ReadTimeout
        {
            get { return stream.ReadTimeout; }
            set { stream.ReadTimeout = value; }
        }

        //
        // Summary:
        //     Gets or sets a value, in miliseconds, that determines how long the stream
        //     will attempt to write before timing out.
        //
        // Returns:
        //     A value, in miliseconds, that determines how long the stream will attempt
        //     to write before timing out.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The System.IO.Stream.WriteTimeout method always throws an System.InvalidOperationException.
        public override int WriteTimeout
        {
            get { return stream.WriteTimeout; }
            set { stream.WriteTimeout = value; }
        }

        //
        // Summary:
        //     Asynchronously reads the bytes from the current stream and writes them to
        //     another stream, using a specified buffer size and cancellation token.
        //
        // Parameters:
        //   destination:
        //     The stream to which the contents of the current stream will be copied.
        //
        //   bufferSize:
        //     The size, in bytes, of the buffer. This value must be greater than zero.
        //     The default size is 4096.
        //
        //   cancellationToken:
        //     The token to monitor for cancellation requests. The default value is System.Threading.CancellationToken.None.
        //
        // Returns:
        //     A task that represents the asynchronous copy operation.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     destination is null.
        //
        //   System.ArgumentOutOfRangeException:
        //     buffersize is negative or zero.
        //
        //   System.ObjectDisposedException:
        //     Either the current stream or the destination stream is disposed.
        //
        //   System.NotSupportedException:
        //     The current stream does not support reading, or the destination stream does
        //     not support writing.
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return stream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        public override void Flush()
        {
            stream.Flush();
        }

        //
        // Summary:
        //     Asynchronously clears all buffers for this stream, causes any buffered data
        //     to be written to the underlying device, and monitors cancellation requests.
        //
        // Parameters:
        //   cancellationToken:
        //     The token to monitor for cancellation requests. The default value is System.Threading.CancellationToken.None.
        //
        // Returns:
        //     A task that represents the asynchronous flush operation.
        //
        // Exceptions:
        //   System.ObjectDisposedException:
        //     The stream has been disposed.
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return stream.FlushAsync(cancellationToken);
        }

        public override long Length
        {
            get { return stream.Length; }
        }

        public override long Position
        {
            get { return stream.Position; }
            set { stream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }

        //
        // Summary:
        //     Asynchronously reads a sequence of bytes from the current stream, advances
        //     the position within the stream by the number of bytes read, and monitors
        //     cancellation requests.
        //
        // Parameters:
        //   buffer:
        //     The buffer to write the data into.
        //
        //   offset:
        //     The byte offset in buffer at which to begin writing data from the stream.
        //
        //   count:
        //     The maximum number of bytes to read.
        //
        //   cancellationToken:
        //     The token to monitor for cancellation requests. The default value is System.Threading.CancellationToken.None.
        //
        // Returns:
        //     A task that represents the asynchronous read operation. The value of the
        //     TResult parameter contains the total number of bytes read into the buffer.
        //     The result value can be less than the number of bytes requested if the number
        //     of bytes currently available is less than the requested number, or it can
        //     be 0 (zero) if the end of the stream has been reached.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     buffer is null.
        //
        //   System.ArgumentOutOfRangeException:
        //     offset or count is negative.
        //
        //   System.ArgumentException:
        //     The sum of offset and count is larger than the buffer length.
        //
        //   System.NotSupportedException:
        //     The stream does not support reading.
        //
        //   System.ObjectDisposedException:
        //     The stream has been disposed.
        //
        //   System.InvalidOperationException:
        //     The stream is currently in use by a previous read operation.
        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return stream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        //
        // Summary:
        //     Reads a byte from the stream and advances the position within the stream
        //     by one byte, or returns -1 if at the end of the stream.
        //
        // Returns:
        //     The unsigned byte cast to an Int32, or -1 if at the end of the stream.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     The stream does not support reading.
        //
        //   System.ObjectDisposedException:
        //     Methods were called after the stream was closed.
        public override int ReadByte()
        {
            return stream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }

        //
        // Summary:
        //     Asynchronously writes a sequence of bytes to the current stream, advances
        //     the current position within this stream by the number of bytes written, and
        //     monitors cancellation requests.
        //
        // Parameters:
        //   buffer:
        //     The buffer to write data from.
        //
        //   offset:
        //     The zero-based byte offset in buffer from which to begin copying bytes to
        //     the stream.
        //
        //   count:
        //     The maximum number of bytes to write.
        //
        //   cancellationToken:
        //     The token to monitor for cancellation requests. The default value is System.Threading.CancellationToken.None.
        //
        // Returns:
        //     A task that represents the asynchronous write operation.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     buffer is null.
        //
        //   System.ArgumentOutOfRangeException:
        //     offset or count is negative.
        //
        //   System.ArgumentException:
        //     The sum of offset and count is larger than the buffer length.
        //
        //   System.NotSupportedException:
        //     The stream does not support writing.
        //
        //   System.ObjectDisposedException:
        //     The stream has been disposed.
        //
        //   System.InvalidOperationException:
        //     The stream is currently in use by a previous write operation.
        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return stream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        //
        // Summary:
        //     Writes a byte to the current position in the stream and advances the position
        //     within the stream by one byte.
        //
        // Parameters:
        //   value:
        //     The byte to write to the stream.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurs.
        //
        //   System.NotSupportedException:
        //     The stream does not support writing, or the stream is already closed.
        //
        //   System.ObjectDisposedException:
        //     Methods were called after the stream was closed.
        public override void WriteByte(byte value)
        {
            stream.WriteByte(value);
        }
    }
}
