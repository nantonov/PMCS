import ownerService from "../Services/ownerService";

export async function createRequestForPetsService(pet) {
    const ownerId = await ownerService.getByUserId().then((owner) => owner.id);
    const request = {
        name: pet.name,
        info: pet.info,
        birthDate: pet.birthDate,
        weight: pet.weight,
        ownerId: ownerId
    };

    return request;
}