using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace TankiTools
{
    static class YouTube
    {
        private static long file_length;
        private static OtherHelper sender;

        public static async Task Upload(OtherHelper form, string path, string privacy, CancellationToken token)
        {
            sender = form;
            ClientSecrets secrets = new ClientSecrets();
            secrets.ClientId = "769375267841-4401scf3hltnavuthdaipoduootau2hk.apps.googleusercontent.com";
            secrets.ClientSecret = "7pgdfz5NLEVmNregj7gkgz4W";
            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    secrets, new[] { YouTubeService.Scope.YoutubeUpload }, "user", CancellationToken.None);

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });

            FileInfo file = new FileInfo(path);
            file_length = file.Length;
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = file.Name;
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = privacy;
            

            using (var fileStream = new FileStream(file.FullName, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                long maxchunk = (long)Math.Round((float)file_length / 100);
                int minchunk = ResumableUpload<Video>.MinimumChunkSize;
                if (minchunk >= maxchunk)
                {
                    videosInsertRequest.ChunkSize = minchunk;
                }
                else
                {
                    videosInsertRequest.ChunkSize = minchunk * (int)Math.Floor((float)maxchunk / minchunk);
                }
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;
                //token.ThrowIfCancellationRequested();
                await videosInsertRequest.UploadAsync(token);
            }
        }

        static void videosInsertRequest_ProgressChanged(IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Uploading:
                    sender.ChangeProgressBar(Convert.ToInt32((float)progress.BytesSent / file_length * 100));
                    break;

                case UploadStatus.Failed:
                    MessageBox.Show("Ошибка загрузки", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        static void videosInsertRequest_ResponseReceived(Video video)
        {
            sender.UploadVideoCompleted(video.Id);
        }
    }
}