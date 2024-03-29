﻿using CoffeeBack.Data.Models;
using CoffeeBack.Data.Repositories;
using CoffeeBack.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.Services
{
    public interface IVideoLectureService
    {
        Task<VideoLectureWithIsWatched> SetVideoLectureWatched(int videoLectureId, int personId, bool isWatched);
        Task<IEnumerable<VideoLectureWithIsWatched>> GetVideoLecturesWithIsWatchedByPerson(int personId);
    }

    public class VideoLectureService : IVideoLectureService
    {
        private readonly IVideoLectureRepository videoLectureRepository;
        private readonly IPersonRepository personRepository;

        public VideoLectureService(
            IVideoLectureRepository videoLectureRepository,
            IPersonRepository personRepository)
        {
            this.videoLectureRepository = videoLectureRepository;
            this.personRepository = personRepository;
        }

        public async Task<VideoLectureWithIsWatched> SetVideoLectureWatched(int videoLectureId, int personId, bool isWatched)
        {
            var videoLecture = await videoLectureRepository.Tracked
                .Include(vl => vl.LearnedPeople)
                .FirstOrDefaultAsync(vl => vl.Id == videoLectureId);
            if (videoLecture == null)
            {
                throw new Exception("Can't find video lecture");
            }

            var currentUser = await personRepository.Untracked.FirstOrDefaultAsync(p => p.Id == personId);

            if (currentUser == null)
            {
                throw new Exception("Can't find user");
            }
            if (isWatched)
            {
                videoLecture.LearnedPeople.Add(currentUser);
            }
            else
            {
                videoLecture.LearnedPeople.Remove(currentUser);
            }

            videoLectureRepository.Update(videoLecture);
            await videoLectureRepository.Save();

            return new VideoLectureWithIsWatched(videoLecture.Id, videoLecture.Name, videoLecture.Source, isWatched);
        }

        public async Task<IEnumerable<VideoLectureWithIsWatched>> GetVideoLecturesWithIsWatchedByPerson(int personId)
        {
            return await videoLectureRepository.Untracked
                .Include(vl => vl.LearnedPeople)
                .Select(vl => new VideoLectureWithIsWatched(vl.Id, vl.Name, vl.Source, vl.LearnedPeople.Any(lp => lp.Id == personId)))
                .ToArrayAsync();
        }
    }
}
