using Business.Abstract;
using Business.Constans;
using Core.Results.Utilities;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile,CarImage carImage,)
        {
            var ımageCount = _carImageDal.GetAll().Count;
            if (ımageCount >= 5)
            {
                return new ErrorResult("ne car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(formFile);
            if (!imageResult.Succes)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccesResult("Car image added.");
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.CarId == carImage.CarId);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccesResult("Image was deleted successfully");
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarId == carImage.CarId);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Succes)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Uptade(carImage);
            return new SuccesResult("Car image updated");
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccesDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }


        //business rules
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(");
            }

            return new SuccesResult();
        }

        private IDataResult<List<Images>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDAL.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<Images> carimage = new List<Images>();
                    carimage.Add(new Images { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<Images>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<Images>>(exception.Message);
            }

            return new SuccessDataResult<List<Images>>(_carImageDAL.GetAll(p => p.CarId == id).ToList());
        }
        private IResult CarImageDelete(Images carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
    }
}
